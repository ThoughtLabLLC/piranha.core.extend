Vue.component("heading-field", {
	props: ["uid", "model"],
	data: function () {
		return {
			body: this.model.value
		};
	},
	template:
		`<div class="heading-field">
		</div>`
});