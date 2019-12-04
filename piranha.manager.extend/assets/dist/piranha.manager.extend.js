Vue.component("code-field", {
	props: ["uid", "model"],
	data: function () {
		return {
			body: this.model.value
		};
	},
	template:
		`<div class="code-field">
			<textarea></textarea>
		</div>`
});
Vue.component("color-field", {
	props: ["uid", "model"],
	template:
		`<div class="color-field">
		</div>`
});
Vue.component("heading-field", {
	props: ["uid", "model", "meta"],
	methods: {
		update: function () {
			if (this.meta.notifyChange) {
				this.$emit("update-field", {
					uid: this.uid,
					title: this.model.value
				});
			}
		}
	},
	template:
		`<div class="heading-field row">
			<div class="col-9">
				<input type="text" class="form-control" v-model="model.value" v-on:change="update()">
			</div>
			<div class="col-3">
				<select class="form-control" v-model="model.headingLevel">
					<option value="0">None</option>
					<option value="1">H1</option>
					<option value="2">H2</option>
					<option value="3">H3</option>
					<option value="4">H4</option>
					<option value="5">H5</option>
					<option value="6">H6</option>
				</select>
			</div>
		</div>`
});
Vue.component("link-field", {
	props: ["uid", "model"],
	methods: {

	},
	template:
		`<div class="link-field">
			
		</div>`
});