var Person = {
    init: function (firstName, lastName, age) {
        this._firstName = firstName;
        this._lastName = lastName;
        this._age = age;
    },

    introduce: function () {
        var strRepresentation =  "Name: " + this._firstName + " " + this._lastName + ", Age: " + this._age;

        return strRepresentation;
    }
}

var Student = Person.extend({
    init: function (firstName, lastName, age, grade) {
        this._super = Object.create(this._super); 
        this._super.init(firstName, lastName, age);
        this._grade = grade;
    },

    introduce: function () {
        var strRepresentation = this._super.introduce()  +", grade: " + this._grade;
        return strRepresentation;
    }
});

var Teacher = Person.extend({
    init: function (firstName, lastName, age, speciality) {
        this._super = Object.create(this._super);
        this._super.init(firstName, lastName, age);
        this._speciality = speciality;
    },
    introduce: function () {
        var strRepresentation = this._super.introduce() + ", speciality: " + this._speciality;
        return strRepresentation;
    }
});

var Class = {
    init: function (capacity, form_teacher) {
        this._capacity = capacity;
        this._formTeacher = formTeacher;
        this._students = new [capacity];
    },

    appendStudent: function (student) {

    },
}

var School = {
    init: function (name, town) {
        this._name = name;
        this._town = town;
        this.classes = new [];
    },
}

var test = Object.create(Person);
test.init("Pesho", "Peshev");
console.log(test.introduce());

var manhattan = Object.create(Student);
manhattan.init("Nikolay", "Kostadinov", 38, "Ninja");
var drugarkata = Object.create(Teacher);
drugarkata.init("Майчето", "Манолова", 45, "Изрoд");

console.log(manhattan.introduce());
console.log(drugarkata.introduce());

