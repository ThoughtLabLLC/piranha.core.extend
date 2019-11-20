Vue.component("complex-block", {
	props: ["uid", "toolbar", "model"],
	methods: {
		selectItem: function (item) {
			for (var n = 0; n < this.model.items.length; n++) {
				if (this.model.items[n] == item) {
					this.model.items[n].isActive = true;
				} else {
					this.model.items[n].isActive = false;
				}
			}
		},
		removeItem: function (item) {
			var itemActive = item.isActive;
			var itemIndex = this.model.items.indexOf(item);

			this.model.items.splice(itemIndex, 1);

			if (itemActive) {
				this.selectItem(this.model.items[Math.min(itemIndex, this.model.items.length - 1)]);
			}
		},
		addGroupBlock: function (type, pos) {
			var self = this;

			fetch(piranha.baseUrl + "manager/api/content/block/" + type)
				.then(function (response) { return response.json(); })
				.then(function (result) {
					self.model.items.push(result.body);
					self.selectItem(result.body);
				})
				.catch(function (error) {
					console.log("error:", error);
				});
		},
		updateTitle: function (e) {
			for (var n = 0; n < this.model.items.length; n++) {
				if (this.model.items[n].meta.uid === e.uid) {
					this.model.items[n].meta.title = e.title;
					break;
				}
			}
		},
		moveItem: function (from, to) {
			this.model.items.splice(to, 0, this.model.items.splice(from, 1)[0])
		}
	},
	mounted: function () {
		var self = this;

		sortable("#" + this.uid + " .list-group", {
			items: ":not(.unsortable)"
		})[0].addEventListener("sortupdate", function (e) {
			self.moveItem(e.detail.origin.index, e.detail.destination.index);
		});
	},
	beforeDestroy: function () {
	},
	template:
		"<div :id='uid' class='block-group'>" +
		"  <div class='block-group-header'>" +
		"    <div class='form-group' v-for='field in model.fields'>" +
		"      <label>{{ field.meta.name }}</label>" +
		"      <component v-bind:is='field.meta.component' v-bind:uid='field.meta.uid' v-bind:meta='field.meta' v-bind:toolbar='toolbar' v-bind:model='field.model'></component>" +
		"    </div>" +
		"  </div>" +
		"</div>"
});