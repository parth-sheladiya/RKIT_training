//encapsulation
console.log("----------encapsulation----------")
class BankDetails {
    #acc_Num;
    #balance; 

    constructor(acc_Num, balance) {
        this.#acc_Num = acc_Num; 
        this.#balance = balance;  
    }

    getBalance() {
        return this.#balance;
    }

    addMoneyInAccount(amount) {
        if (amount > 0) {
            this.#balance += amount;
            console.log(`You have added ${amount} new balance is ${this.#balance}`);
        } else {
            console.log("Invalid amount");
        }
    }

    withdrawMoney(amount) {
        if (amount > 0 && amount <= this.#balance) {
            this.#balance -= amount;
            console.log(`You have withdrawn ${amount} new balance is ${this.#balance}`);
        } else {
            console.log("Invalid amount ");
        }
    }
}

const myBankAccount = new BankDetails(30606054413, 88632);

console.log(myBankAccount.getBalance());   
console.log(myBankAccount.balance);
console.log(myBankAccount.acc_Num);
myBankAccount.addMoneyInAccount(54052);     
myBankAccount.withdrawMoney(91526);         



// inheritance
console.log("----------inheritance----------")
class bankDetails {
    constructor(accNum ,accHolderName , balance){
        this.accNum =accNum;
        this.accHolderName=accHolderName;
        this.balance=balance;
    }
    getBalance(){
        return this.balance;
    }
    addmoneyInAccount(amount){
        if(amount>=0){
            this.balance+=amount;
            console.log(`you have add ${amount} new balance is ${this.balance}`);
        }
        else{
            console.log("invalid amount")
        }
    }

}

class SavingAccount extends bankDetails{
    constructor(accNum,accHolderName,balance , interestRate){
        super(accNum,accHolderName,balance)
        this.interestRate=interestRate;
    }

    addIntrest(){
        let intrest = this.balance * (this.interestRate/100);
        this.balance+=intrest;
        console.log(`intrest is ${intrest} . new balance is ${this.balance}`)
    }
}
const myaccount = new SavingAccount(11040,"parth",3500000,7.25);
myaccount.addmoneyInAccount(0);
myaccount.addIntrest();
console.log(myaccount.getBalance());


// polymorphisam
console.log("----------polymorphisam----------")
class employee{
    constructor(empName,empRole){
        this.empName=empName;
        this.empRole=empRole;
    }

    getDetails(){
        console.log(`employee name ${this.empName} & role ${this.empRole}`)
    }
}

class manager extends employee{
    constructor(empName,empRole,department){
        super(empName,empRole);
        this.department=department;
    }

    getDetails(){
        super.getDetails();
        console.log(`department is ${this.department}`)
    }
}

const person = new manager("parth" ,"dotnet","tech")
person.getDetails();


class newemployee {
    constructor(fname){
        this.fname=fname;
    }

    getDetails(){
        return `employee name is ${this.fname}`
    }
}

class newmanager extends newemployee {
    constructor(fname , department){
        super(fname);
        this.department=department;
    }

    getDetails(){
        super.getDetails();
         return (`manager nam is ${this.fname} & department is ${this.department}`)
    }
}

class developer extends newemployee {
    constructor(fname,role){
        super(fname);
        this.role=role;
    }

    getDetails(){
        super.getDetails();
        return (`developer name is ${this.fname} & role is ${this.role}`);
    }
}

const empPerson = new newemployee("parth");
const managerPerson = new newmanager("ravi" , "purchase");
const developerPerson = new developer("raj" ,"react");


console.log(empPerson.getDetails());
console.log(managerPerson.getDetails());
console.log(developerPerson.getDetails());





// abstraction
console.log("----------abstraction----------")
class car{
    constructor(){
        this.fuelLevel=1000;
        this.engineStart=false;
    }
    startCar(){
        if(this.checkFuel()){
            this.engineStart=true;
            console.log(`car start , your fuel level is ${this.fuelLevel}`);

        }
        else{
            console.log("car not startt , fuel level is low ,please  refuel your car")
        }
    }
    stopCar(){
        this.engineStart=false;
        console.log("car stop");

    }
    checkFuel(){
        return this.fuelLevel>20;

    }

    refuel(amount){
        this.fuelLevel+=amount;
        console.log(`you can add ${amount}rs fuel. new fuel level is ${this.fuelLevel}`);

    }
}


const mycar = new car();
mycar.startCar();
mycar.stopCar();
mycar.refuel(300);
mycar.startCar();
