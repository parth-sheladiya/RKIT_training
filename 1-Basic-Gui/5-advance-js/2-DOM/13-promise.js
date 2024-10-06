let firstPromise = new Promise((resolve, reject) =>{
    console.log("hello javascript");
    resolve(1001);
    reject(new Error("internam server error"))
})

let secondPromise = new Promise((resolve, reject) =>{
    setTimeout(function myName(){
        console.log("hello world");
    },3000);
    resolve (1);
})


let thirdPromise = new Promise((resolve, reject) =>{
    let success = true;
    if(success){
        resolve("promise fullfilled")
    }
    else{
        reject("promise rejected")
    }
})

thirdPromise.then((message)=>{
    console.log("then massage is" + message)
}).catch((error)=>{
    console.log("error" + error)
})


let fourthPromise = new Promise((resolve, reject) =>{
    let success = false;
    if(success){
        resolve("promise fullfilled")
    }
    else{
        reject("promise rejected")
    }
})

fourthPromise.then((message)=>{
    console.log("first message" + message)
    return 'promise fullfilled second message '
}).then((message)=>{
    console.log("second message" + message)
    return 'promise full filled third message'
}).then((message)=>{
    console.log('third message' + message)
})
.catch((error)=>{
    console.log("error" + error)
}).finally((message)=>{
    console.log("must be execute if resolve or reject")
})


let promiseFirst = new Promise((resolve, reject)=>{
    setTimeout(resolve , 1000, "first")
})
let promiseSecond = new Promise((resolve, reject)=>{
    setTimeout(resolve , 2000, "second")
})
let promiseThird = new Promise((resolve, reject)=>{
    setTimeout(resolve , 3000, "third")
})
let promiseFourth = new Promise((resolve, reject)=>{
    setTimeout(reject , 4000, "fourth")
})
Promise.all([promiseFirst, promiseSecond, promiseThird, promiseFourth])
.then((values)=>{
    console.log(values)
})
.catch((error)=>{
    console.error("error" + error)
})