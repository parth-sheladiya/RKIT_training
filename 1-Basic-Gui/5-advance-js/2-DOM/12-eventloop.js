console.log("hello javascript");

setTimeout(function(){
    console.log("after 5000 miliseconds task move queue to stack");
}, 5000);

console.log("hello c++");


settimeout
function sayHello(){
    console.log("hello everyone")
}

setTimeout(sayHello, 2000);

console.log("first execution")

// passing arguments
function sayPassed(name){
    console.log("Hello" + name + "!");
}

setTimeout(sayPassed,2000,"parth");

setTimeout(function(){
    console.log("hello javascript")
},2000)


