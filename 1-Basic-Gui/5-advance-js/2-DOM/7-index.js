


function changeText(){
    let fPara = document.getElementById('firstPara')
    fPara.textContent = "hello c++";   
}

let fPara = document.getElementById('firstPara')
fPara.addEventListener('click',changeText);
// fPara.removeEventListener('click',changeText);


function changeColor(){
    let getBtnInfo = document.getElementById('fBtn');
    getBtnInfo.style.backgroundColor='blue'
}
let getBtnInfo = document.getElementById("fBtn");
getBtnInfo.addEventListener('click',changeColor);


function changeEvent(event){
    // let getInputInfo= document.getElementById('fInput');
    console.log(event)
    console.log(event.target.value)
}
let getInputInfo= document.getElementById('fInput');
getInputInfo.addEventListener('input',changeEvent);


