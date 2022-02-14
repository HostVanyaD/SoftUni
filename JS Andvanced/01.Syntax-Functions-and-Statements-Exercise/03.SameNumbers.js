function solve(number){
    let numAsString = String(number);
    let flag = true;
    let sum = 0;
    
    for (let i = 0; i < numAsString.length - 1; i++) {
        if (numAsString[i] != numAsString[i + 1]) {
            flag = false;
        }
        sum += Number(numAsString[i]);
    }
    sum += Number(numAsString[numAsString.length - 1]);

    console.log(flag);
    console.log(sum);
}

solve(1234);
solve(2222222);
