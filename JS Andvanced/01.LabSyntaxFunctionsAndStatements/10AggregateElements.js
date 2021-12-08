function aggregateElements(array){
    let numbersArray = array.map(Number);
    let sum = numbersArray.reduce((a, b) => a + b);
 
    let inverseValuesSum = 0;
 
    for (let i = 0; i < numbersArray.length; i++) {
        inverseValuesSum += 1 / numbersArray[i];
    }
 
    let stringConcat = numbersArray.join('');
 
    console.log(sum);
    console.log(inverseValuesSum);
    console.log(stringConcat);
}