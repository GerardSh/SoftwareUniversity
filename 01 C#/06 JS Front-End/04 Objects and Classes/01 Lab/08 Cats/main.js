function solve(cats) {
    class Cat {
        constructor(name, age) {
            this.name = name;
            this.age = age;
        }

        meow() {
            console.log(`${this.name}, age ${this.age} says Meow`);
        }
    }

    for (let cat of cats) {
        let [name, age] = cat.split(' ');
        new Cat(name, age).meow();
    }
}




//2
function solve(cats) {
    class Cat {
        constructor(name, age) {
            this.name = name;
            this.age = age;
        }

        meow() {
            console.log(`${this.name}, age ${this.age} says Meow`);
        }
    }

    cats
        .map(x => x.split(' '))
        .map(([name, age]) => new Cat(name, age))
        .forEach(x => x.meow())
}
