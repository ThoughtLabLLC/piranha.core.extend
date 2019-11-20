"use strict";

const gulp = require("gulp");
const merge = require("merge-stream");
const common = require("../common");
const plumber = require("gulp-plumber");
const bundles = require("../bundle.common");
const concat = require("gulp-concat");

function createBundleTask(name, dependencies, regex, renameFn) {
    gulp.task(name, dependencies, function () {
        return merge(bundles.match(regex).map(function (bundle) {
            return gulp
                .src(bundle.inputFiles.map(renameFn), { base: "." })
                .pipe(plumber())
                .pipe(concat(bundle.outputFileName))
                .pipe(gulp.dest(common.paths.wwwroot))
                .pipe(plumber.stop());
        }))
    });
}

createBundleTask("bundle:css", ["build:css"], common.patterns.css, common.renameScssToCss);

createBundleTask("bundle:js", ["build:js"], common.patterns.js, common.renameTsToJs);

gulp.task("bundle", ["bundle:css", "bundle:js"]);