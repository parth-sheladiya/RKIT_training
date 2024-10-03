// var hoisting and var declaration sirf top of the scope kar sakte hai vo bhi sirf var me 
// let ya const me nahi  ho sakta 
console.log(firstNum);
var firstNum=10;
// var ke case me var declare shift hota hai par value shift nahi hoti isliye assign nahi hoti
// isliye undefined aata hai

firstFunction();
function firstFunction(){
    console.log("first functiomn")
}
// function ke case me pura ka pura shift hota hai


console.log(secondFunction)
var secondFunction = function(){
    console.log("second Function")
}


// console.log(firstJunction)
// let firstJunction = 10;

// console.log(thirdFunction)
// let thirdFunction = function(){
//     console.log("second Function")
// }



// function in array 

let arr = [
    function (a,b){
        return a+b;
    },
    function (a,b){
        return a-b;
    },
    function (a,b){
        return a*b;
    },function (a,b){
        return a/b;
    }
]

let first = arr[3];
let finalAnswer= first(7,8);
console.log(finalAnswer)