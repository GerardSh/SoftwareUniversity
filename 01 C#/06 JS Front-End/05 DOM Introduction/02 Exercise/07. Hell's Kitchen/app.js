function solve() {
   document.querySelector('#btnSend').addEventListener('click', onClick);

   function onClick() {
      let input = document.getElementsByTagName('textarea')[0].value;
      const restaurantsInfo = JSON.parse(input);

      const restaurants = [];

      for (const currentRestaurant of restaurantsInfo) {
         const [restaurantName, workers] = currentRestaurant.split(' - ');

         let restaurant = restaurants.find(x => x.name == restaurantName);

         if (!restaurant) {
            restaurant = {
               name: restaurantName,
               workers: [],

               averageSalary() {
                  return (this.workers.reduce((aggr, currentWorker) => aggr + currentWorker.payment, 0) / restaurant.workers.length).toFixed(2);
               },
               highestSalary() {
                  return this.workers.sort((a, b) => b.payment - a.payment)[0].payment.toFixed(2);
               }
            }

            restaurants.push(restaurant);
         }

         for (const worker of workers.split(', ')) {
            const [name, payment] = worker.split(' ');

            restaurant.workers.push({ name, payment: Number(payment) });
         }
      }

      const bestRestaurant = restaurants.sort((a, b) => b.averageSalary() - a.averageSalary())[0];

      bestRestaurant.workers.sort((a, b) => b.payment - a.payment);

      const bestRestaurantWorkers = bestRestaurant.workers.map(x => `Name: ${x.name} With Salary: ${x.payment}`);
      const bestRestaurantInformation = `Name: ${bestRestaurant.name} Average Salary: ${bestRestaurant.averageSalary()} Best Salary: ${bestRestaurant.highestSalary()}`

      document.getElementById('bestRestaurant').children[2].textContent = bestRestaurantInformation;
      document.getElementById('workers').children[2].textContent = bestRestaurantWorkers.join(' ');
   }
}
