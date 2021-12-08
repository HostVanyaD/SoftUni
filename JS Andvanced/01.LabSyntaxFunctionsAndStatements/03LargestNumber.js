function largestNum(arg1, arg2, arg3){
    let largestNumber;
    if(arg1 > arg2 && arg1 > arg3){
        largestNumber = arg1;
    } else if(arg2 > arg1 && arg2 > arg3){
        largestNumber = arg2;
    } else if(arg3 > arg1 && arg3 > arg2){
        largestNumber = arg3;
    }

    console.log(`The largest number is ${largestNumber}.`);
}