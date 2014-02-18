/// <reference path="classical-oop.js" />
/// <reference path="underscore.js" />
// Write a function that by a given array of students finds the student with highest marks
(function () {

    var student = Class.create({
        init: function (firstName, lastName, age, score) {
            this.firstName = firstName;
            this.lastName = lastName;
            this.age = age;
            this.score = score;
            var that = this;
        },
        toString: function () {
            return this.firstName + " " + this.lastName + " " + this.age + " " + this.score;
        }

    });

    var students = [
        new student("Nikolay", "Kostadinov", 10, 6),
        new student("Ilina", "Kostadinova", 20, 4),
        new student("Hristo", "Grigorov", 18, 3),
        new student("Svilen", "Boshnakov", 23, 2),
        new student("Detelin", "Yolov", 24, 5),
        new student("Kosta", "Kiryazov", 50, 6),
    ];

    function findStudets(students) {
        var theBest = _.max(students, function (item) { return item.score })
        console.log(theBest.toString());
    }

    findStudets(students);
})()

