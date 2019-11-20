"use strict";

const gulp = require("gulp");
const merge = require("merge-stream");
const bundles = require("../bundle.common");
const common = require("../common");
const plumber = require("gulp-plumber");
const rename = require("gulp-rename");
const autoprefixer = require("autoprefixer");
const ts = require("gulp-typescript");
const sass = require("gulp-sass");
const postcss = require("gulp-postcss");

const tsProject = ts.createProject("tsconfig.json");

gulp.task("build:css", function () {
    return merge(bundles.getFilesToCompile(common.patterns.scss).map(function (file) {
        return gulp
            .src(file, { base: "." })
            .pipe(plumber())
            .pipe(rename(function (path) {
                path.extname = ".css";
            }))
            .pipe(sass({
                "includePath": "",
                "indentType": "space",
                "indentWidth": 2,
                "outputStyle": "nested",
                "Precision": 5,
                "relativeUrls": true,
                "sourceMapRoot": "",
                "sourceMap": false
            }))
            .pipe(postcss([autoprefixer({
                grid: true
            })]))
            .pipe(gulp.dest("."))
            .pipe(plumber.stop());
    }));
});

gulp.task("build:js", function () {
    return gulp
        .src(bundles.getFilesToCompile(common.patterns.ts).concat("scripts/typings/**/*.d.ts"), { base: "." })
        .pipe(tsProject())
        .js.pipe(gulp.dest("."));
});

gulp.task("build", ["build:css", "build:js", "build:mjml"]);