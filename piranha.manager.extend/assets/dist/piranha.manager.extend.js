Vue.component("code-field", {
	props: ["uid", "model"],
	template:
		`<div class="code-field">
			<ul class="nav nav-tabs" id="codeTabs" role="tablist">
				<li class="nav-item">
					<a class="nav-link active" id="html-tab" data-toggle="tab" href="#html" role="tab" aria-controls="html" aria-selected="true">HTML</a>
				</li>
				<li class="nav-item">
					<a class="nav-link" id="css-tab" data-toggle="tab" href="#css" role="tab" aria-controls="css" aria-selected="false">CSS</a>
				</li>
			</ul>
			<div class="tab-content" id="codeContent">
				<div class="tab-pane fade show active" id="html" role="tabpanel" aria-labelledby="html-tab">
					<textarea class="form-control" v-model="model.html"></textarea>
				</div>
				<div class="tab-pane fade" id="css" role="tabpanel" aria-labelledby="css-tab">
					<textarea class="form-control" v-model="model.css"></textarea>
				</div>
			</div>
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