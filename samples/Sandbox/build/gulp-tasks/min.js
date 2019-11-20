"use strict";

const gulp = require("gulp");
const common = require("../common");
const bundles = require("../bundle.common");
const uglify =  require("gulp-uglify");
const cleanCss = require("gulp-clean-css");
const concat = require("gulp-concat");
const merge = require("merge-stream");

function byMinificationEnabled(bundle) {
    return !!bundle.minify && bundle.minify.enabled === true;
}

function createMinifyTask(name, dependencies, regex, minifyFn) {
    gulp.task(name, dependencies, function () {
        return merge(bundles.match(regex).filter(byMinificationEnabled).map(function (bundle) {
            return gulp
                .src(common.paths.wwwroot + "/" + bundle.outputFileName, { base: "." })
                .pipe(concat(common.generateMinifiedFileName(bundle.outputFileName)))
                .pipe(minifyFn())
                .pipe(gulp.dest(common.paths.wwwroot));
        }));
    });
}

createMinifyTask("min:css", ["bundle:css"], common.patterns.css, cleanCss);

createMinifyTask("min:js", ["bundle:js"], common.patterns.js, uglify);

gulp.task("min", ["min:css", "min:js"]);