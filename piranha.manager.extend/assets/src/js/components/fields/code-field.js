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