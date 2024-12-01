class car{
    static startEngine(){
        return "start engine";
    }
}
console.log(car.startEngine());


class myCar{
    constructor(brand){
        this.brand=brand;
    }
    static numOfWheels =4;
}
const xuv = new myCar("innova");
console.log(myCar.numOfWheels);


class bankAccount {
    
    static totalAccounts = 0;

    constructor(owner, balance) {
        this.owner = owner;
        this.balance = balance;
        bankAccount.totalAccounts++; 
    }

    deposit(amount) {
        this.balance += amount;
        console.log(`${this.owner} deposited ${amount}. New balance: ${this.balance}`);
    }

    
    withdraw(amount) {
        if (amount <= this.balance) {
            this.balance -= amount;
            console.log(`${this.owner} withdrew ${amount}. New balance: ${this.balance}`);
        } else {
            console.log("Insufficient balance!");
        }
    }

    static getTotalAccounts() {
        return `Total Bank Accounts: ${bankAccount.totalAccounts}`;
    }
}


const account1 = new bankAccount("Alice", 1000);
const account2 = new bankAccount("Bob", 500);


account1.deposit(200);
account2.withdraw(100);

console.log(bankAccount.getTotalAccounts()); 
