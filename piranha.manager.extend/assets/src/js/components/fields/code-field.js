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