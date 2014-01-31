var Person = {
    init: function (firstName, lastName, age) {
        this._firstName = firstName;
        this._lastName = lastName;
        this._age = age;
    },

    introduce: function () {
        var strRepresentation = "Name: " + this._firstName + " " + this._lastName + ", Age: " + this._age;

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
        var strRepresentation = this._super.introduce() + ", grade: " + this._grade;
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
    init: function (capacity, formTeacher) {
        this._capacity = capacity;
        this._formTeacher = formTeacher;
        this._students = [];
    },

    appendStudent: function (student) {

        if (this._students.length == this._capacity) {
            throw new Error("Capacity of class is exided!");
        }

        this._students.push(student);
    },

    toString: function () {
        var strRepresentation = "The former teacher of this class is: " + this._formTeacher.introduce() + '\n';
        for (var i = 0; i < this._students.length; i++) {
            if (this._students[i].introduce) {
                strRepresentation += this._students[i].introduce() + "\n";
            }
        }
        return strRepresentation;
    }
}

var School = {
    init: function (name, town) {
        this._name = name;
        this._town = town;
        this._classes = [];
    },
    appendClass: function (aClass) {
        this._classes.push(aClass);
    }
}


var manhattan = Object.create(Student);
manhattan.init("Nikolay", "Kostadinov", 38, "Ninja");

var drugarkata = Object.create(Teacher);
drugarkata.init("Майчето", "Манолова", 45, "Даскалица по простотия");

console.log(manhattan.introduce());
console.log(drugarkata.introduce());

var myClass = Object.create(Class);
myClass.init(34, drugarkata);
myClass.appendStudent(manhattan);

var student = {};

for (var i = 0; i < 34; i++) {

    student = Object.create(Student);
    student.init("FirstName" + (i + 1), "LastName" + (i + 1), i + 7, 3);
    try {
        myClass.appendStudent(student);
    } catch (e) {
        console.log(e.message);
        break;
    }
}

var school = Object.create(School);
school.init("TelerikAcademy", "Sofia");
school.appendClass(myClass);

console.log(myClass.toString());
console.log(school);
