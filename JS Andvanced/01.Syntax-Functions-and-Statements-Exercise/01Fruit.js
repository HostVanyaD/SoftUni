function calcPrice(typeOfFruit, weightOfFruitsInGrams, pricePerKilogram) {

    let fruitsInKilograms = weightOfFruitsInGrams / 1000;

    console.log(`I need $${(fruitsInKilograms * pricePerKilogram).toFixed(2)} to buy ${fruitsInKilograms.toFixed(2)} kilograms ${typeOfFruit}.`);
}

calcPrice('orange', 2500, 1.80);
calcPrice('apple', 1563, 2.35);