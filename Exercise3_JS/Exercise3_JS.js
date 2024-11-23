// Import the prompt-sync library for synchronous user input
const prompt = require('prompt-sync')();

/**
 * 
 * @returns {number[]}
 */
// Function to get an array of numbers from the user, validating constraints
let numsInput = function(){
    var numsInput;
    var isConstraintsValid = true;
    do{
        isConstraintsValid = true;
        numsInput = prompt("Enter the numbers separated by commas: ").split(',').map(Number);

        // Check constraints: all numbers must be between -109 and 109, and the array size must be between 2 and 104
        if(numsInput.find(ni => ni < -109 || ni > 109) || numsInput.length < 2 || numsInput.length > 104){
            isConstraintsValid = false;
            console.log("Something went wrong: ensure all numbers are between -109 and 109, and the input contains between 2 and 104 numbers.");
        }

    }while(!isConstraintsValid); // Loop until the input meets the constraints

    // Return the valid array of numbers
    return numsInput;
}

/**
 * 
 * @returns {number}
 */
// Function to get a target number from the user, validating constraints
let targetInput = function(){
    var targetInput;
    var isConstraintsValid = true;
    do{
        isConstraintsValid = true;
        targetInput = Number(prompt("Enter the target number: "));

        // Check constraints: the target number must be between -109 and 109
        if(targetInput < -109 || targetInput > 109){
            isConstraintsValid = false;
            console.log("Something went wrong: ensure the target number is between -109 and 109");
        }

    }while(!isConstraintsValid); // Loop until the input meets the constraints
    
    // Return the valid target number
    return targetInput;
}

/**
 * 
 * @param {number[]} nums 
 * @param {number} target 
 * @returns {number[] | null}  
 */
// Function to find two indices of numbers in an array that add up to the target
var twoSum = function(nums, target){
    // Create a Map to store numbers and their indices
    let seen = new Map();

    for (let i = 0; i < nums.length; i++) {
        
        // Calculate the complement of the current number (target - current number)
        let complement = target - nums[i];
        
        // Check if the complement exists in the Map
        if (seen.has(complement)) {
            return `[${i}, ${seen.get(complement)}]`;
        }

        // Store the current number and its index in the Map
        seen.set(nums[i], i);
    };

    return null;
}

// Get the validated array of numbers from the user
let nums = numsInput()

// Get the validated target number from the user
let target = targetInput();

console.log(twoSum(nums, target));