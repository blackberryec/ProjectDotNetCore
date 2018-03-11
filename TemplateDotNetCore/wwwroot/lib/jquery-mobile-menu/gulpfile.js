'use strict';

// Include gulp
var gulp = require('gulp');
var less = require('gulp-less');
var cssmin = require('gulp-cssmin');
var rename = require('gulp-rename');
var uglify = require('gulp-uglify');
var jshint = require('gulp-jshint');
var stylish = require('jshint-stylish');
var express = require('express');
var directory = require('serve-index');
var browser = require('open');

//less
gulp.task('less', function () {
  return gulp.src(['./src/*.less'])
    .pipe(less())
    .pipe(gulp.dest('./dest'))
    .pipe(cssmin({
      expand: true,
      keepSpecialComments: 0,
      noAdvanced: true
    })).pipe(rename({
      suffix: '.min',
      extname: '.css'
    })).pipe(gulp.dest('dest'));
});


//scripts
gulp.task('scripts', function () {
  return gulp.src(['./src/*.js'])
    .pipe(gulp.dest('./dest'))
    .pipe(rename({
      suffix: '.min',
      extname: '.js'
    }))
    .pipe(uglify())
    .pipe(gulp.dest('./dest'));
});

gulp.task('lint', function () {
  return gulp.src(['./src/*.js'])
    .pipe(jshint())
    .pipe(jshint.reporter(stylish));
});

//watch Files For Changes
gulp.task('watch', function () {
  var app = express();
  app.use(express.static('./'));
  app.use(directory('./'));
  app.listen(8090);
  browser('http://localhost:8090/demo.html', 'Google Chrome');

  gulp.watch(['src/*.less'], ['less']);
  gulp.watch(['src/*.js'], ['scripts', 'lint']);
});


//tasks aliases
gulp.task('default', ['less', 'scripts']);
