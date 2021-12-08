function calcArea(radius){
    let result;
    if(typeof(radius) === 'number'){
        result = (Math.pow(radius, 2) * Math.PI).toFixed(2);
    } else {
        result = `We can not calculate the circle area, because we receive a ${typeof(radius)}.`;
    }

    console.log(result);
}