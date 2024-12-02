import os from 'os'; // Core module
import sum from './calculator.js'; // Internal module

import { log } from 'console';

console.log(`Hello from Nodejs ${os.EOL} new line`);

log(sum(2, 5)); // Using internal module

myVariable.log(sum(2, 5));
