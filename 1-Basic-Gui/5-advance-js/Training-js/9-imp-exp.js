// const {add} = require('./10-export')

// let sum = add(4,5);
// console.log(sum)



import { add, subtract ,hello } from './10-export.mjs';


const result = hello(2, 3);
console.log(result);


console.log(add(5, 3));       
console.log(subtract(5, 3));  
