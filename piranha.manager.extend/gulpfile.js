/// <binding BeforeBuild='default' />
var gulp = require("gulp"),
	sass = require('gulp-sass'),
	concat = require("gulp-concat"),
	cssmin = require("gulp-cssmin"),
	rename = require("gulp-rename"),
	uglifyes = require('uglify-es'),
	composer = require('gulp-uglify/composer'),
	uglify = composer(uglifyes, console);

var output = "assets/dist/";

var resources = [
	"node_modules/codemirror/lib/*.*",
	"node_modules/codemirror/mode/css/*.*",
	"node_modules/codemirror/addon/hint/show-hint.css",
	"node_modules/codemirror/addon/hint/show-hint.js",
	"node_modules/codemirror/addon/hint/css-hint.js",
	"node_modules/codemirror/addon/hint/html-hint.js"
];

var styles = [];

var scripts = [
	"assets/src/js/components/fields/*.*"
];

gulp.task("min", function () {
	// Copy resources
	var n;
	for (n = 0; n < resources.length; n++) {
		gulp.src(resources[n])
			.pipe(gulp.dest(output));
	}

	// Compile scss
	for (n = 0; n < styles.length; n++) {
		gulp.src(styles[n])
			.pipe(sass().on("error", sass.logError))
			.pipe(cssmin())
			.pipe(rename({
				suffix: ".min"
			}))
			.pipe(gulp.dest(output));
	}

	// Compile js
	gulp.src(scripts, { base: "." })
		.pipe(concat(output + "piranha.manager.extend.js"))
		.pipe(gulp.dest("."))
		.pipe(uglify().on('error', function (e) {
			console.log(e);
		}))
		.pipe(rename({
			suffix: ".min"
		}))
		.pipe(gulp.dest("."));
});

//
// Default tasks
//
gulp.task("serve", ["min"]);
gulp.task("default", ["serve"]);