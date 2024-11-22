nums = [12, 1, 7, 2];
target = 9;
let seen = new Map();

var twoSum = function(nums, target){
    for (let i = 0; i < nums.length; i++) {
        let complement = target - nums[i];
        if (seen.has(complement)) {
            return `[${i}, ${seen.get(complement)}]`;
        }
        seen.set(nums[i], i);
    };
}

console.log(twoSum(nums, target));