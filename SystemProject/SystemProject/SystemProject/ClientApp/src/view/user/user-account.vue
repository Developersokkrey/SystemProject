<template>
<div>
    <form class="bg-white p-5 rounded-lg shadow-lg min-w-full">
      <div class="flex flex-wrap -mx-2 space-y-4 md:space-y-0">
        <div class="w-full px-2 md:w-1/2">
          <label class="text-gray-800 font-semibold block my-3 text-md" for="username">Username</label>
				  <input class="w-full h-8 px-2 text-sm rounded-lg focus:outline-none border" type="text" name="email" id="email" placeholder="Username" />
        </div>
        <div class="w-full px-2 md:w-1/2">
          <div class="form-check">        
              <input type="radio" name="flexRadioDefault">
              <label class="form-check-label inline-block text-gray-800 pl-1 pr-5" for="flexRadioDefault1">
                  Male
              </label>
              <input type="radio" name="flexRadioDefault">
              <label class="form-check-label inline-block text-gray-800 pl-1 pr-5" for="flexRadioDefault1">
                  Female
              </label>
              <input type="radio" name="flexRadioDefault">
              <label class="form-check-label inline-block text-gray-800 pl-1 pr-5" for="flexRadioDefault1">
                  Orther
              </label>
        </div>
      </div>
      <div class="flex flex-wrap -mx-2 space-y-4 md:space-y-0">
        <div class="w-full px-2 md:w-1/2">
          <label class="text-gray-800 font-semibold block my-3 text-md" for="username">Password</label>
				  <input class="w-full h-8 px-2 text-sm rounded-lg focus:outline-none border" type="Password" name="email" id="email" placeholder="Username" />
        </div>
        <div class="w-full px-2 md:w-1/2">
          <label class="text-gray-800 font-semibold block my-3 text-md" for="email">Confirm Password</label>
					<input class="w-full h-8 px-2 text-sm rounded-lg focus:outline-none border" type="Password" name="email" id="email" placeholder="Company" />
        </div>
      </div>
       <div class="flex flex-wrap -mx-2 space-y-4 md:space-y-0">
        <div class="w-full px-2 md:w-1/2">
          <label class="text-gray-800 font-semibold block my-3 text-md" for="email">Rules</label>
					<select class="w-full h-8 px-2 text-sm text-gray-700 placeholder-gray-600 border rounded-lg focus:outline-none">
            <option :value="rule.id" v-for="rule in user_rules" :key="rule.id">{{ rule.title }}</option>
          </select>
        </div>
        <div class="w-full px-2 md:w-1/2">
          <label class="text-gray-800 font-semibold block my-3 text-md" for="email">Status</label>
					<select class="w-full h-8 px-2 text-sm text-gray-700 placeholder-gray-600 border rounded-lg focus:outline-none">
            <option :value="status.id" v-for="status in statuss" :key="status.id ">{{ status.title }}</option>
          </select>
        </div>
      </div>
      <div class="flex flex-wrap -mx-2 space-y-4 md:space-y-0">
        <div class="w-full px-2 pt-7 md:w-1/2 flex space-x-4">
            <div>
                <button type="button" @click="onClickTop" class="nline-block px-4 py-1.5 bg-blue-600 text-white font-medium text-xs leading-tight rounded shadow-md hover:bg-blue-700 hover:shadow-lg focus:bg-blue-700 focus:shadow-lg focus:outline-none focus:ring-0 active:bg-blue-800 active:shadow-lg transition duration-150 ease-in-out">Save</button>
            </div> 
            <div>                
                <button type="button" @click="onClickBot" class="inline-block px-4 py-1.5 bg-yellow-600 text-white font-medium text-xs leading-tight rounded shadow-md hover:bg-yellow-700 hover:shadow-lg focus:bg-yellow-700 focus:shadow-lg focus:outline-none focus:ring-0 active:bg-blue-800 active:shadow-lg transition duration-150 ease-in-out">Clear</button>  
            </div>                  
        </div>
        <div class="w-full px-2 md:w-1/2">
          <div>
            <label class="text-gray-800 font-semibold block my-3 text-md">Gender</label>
            </div>
            <div class="form-check">        
              <input type="radio" name="flexRadioDefault">
              <label class="form-check-label inline-block text-gray-800 pl-1 pr-5" for="flexRadioDefault1">
                  Male
              </label>
              <input type="radio" name="flexRadioDefault">
              <label class="form-check-label inline-block text-gray-800 pl-1 pr-5" for="flexRadioDefault1">
                  Female
              </label>
              <input type="radio" name="flexRadioDefault">
              <label class="form-check-label inline-block text-gray-800 pl-1 pr-5" for="flexRadioDefault1">
                  Orther
              </label>
            </div>
        </div>
      </div> 
		</form>
    <!-- notificationGroup -->
    <div class="text-center">
    <notificationGroup group="top">
            <div class="fixed inset-0 top-12 z-50 flex px-4 py-6 pointer-events-none p-6 items-start justify-end">
              <div class="max-w-sm">
                <notification v-slot="{notifications}">
                  <div class="flex max-w-sm w-full mx-auto bg-white shadow-md rounded-lg overflow-hidden mt-4"
                      v-for="notification in notifications"
                      :key="notification.id">
                    <div class="flex justify-center items-center w-12 bg-green-500">
                      <svg
                        class="h-6 w-6 fill-current text-white"
                        viewBox="0 0 40 40"
                        xmlns="http://www.w3.org/2000/svg">
                        <path
                          d="M20 3.33331C10.8 3.33331 3.33337 10.8 3.33337 20C3.33337 29.2 10.8 36.6666 20 36.6666C29.2 36.6666 36.6667 29.2 36.6667 20C36.6667 10.8 29.2 3.33331 20 3.33331ZM16.6667 28.3333L8.33337 20L10.6834 17.65L16.6667 23.6166L29.3167 10.9666L31.6667 13.3333L16.6667 28.3333Z"
                        ></path>
                      </svg>
                    </div>
                    <div class="-mx-3 py-2 px-4">
                      <div class="mx-3">
                        <span class="text-green-500 font-semibold">{{notification.title}}</span>
                        <p class="text-gray-600 text-sm">{{notification.text}}</p>
                      </div>
                    </div>
                  </div>
                </notification>
              </div>
            </div>
      </notificationGroup>
      <notificationGroup group="bottom" position="bottom">
          <div class="fixed inset-x-3 bottom-6 flex px-2 py-4 p-4 items-start justify-end">
            <div class="max-w-sm max-h-96">
              <notification v-slot="{notifications}">
                <div class="flex max-w-sm w-full mx-auto bg-white shadow-md rounded-lg overflow-hidden mt-2"
                     v-for="notification in notifications"
                     :key="notification.id">
                  <div class="flex max-w-sm justify-center items-center w-12 bg-red-500">
                    <svg class="h-6 w-6 fill-current text-white"
                         viewBox="0 0 40 40"
                         xmlns="http://www.w3.org/2000/svg">
                      <path d="M20 3.36667C10.8167 3.36667 3.3667 10.8167 3.3667 20C3.3667 29.1833 10.8167 36.6333 20 36.6333C29.1834 36.6333 36.6334 29.1833 36.6334 20C36.6334 10.8167 29.1834 3.36667 20 3.36667ZM19.1334 33.3333V22.9H13.3334L21.6667 6.66667V17.1H27.25L19.1334 33.3333Z"></path>
                    </svg>
                  </div>
                  <div class="-mx-3 py-2 px-4">
                    <div class="mx-3">
                      <span class="text-red-500 font-semibold">{{notification.title}}</span>
                      <p class="text-gray-600 text-sm">{{notification.text}}</p>
                    </div>
                  </div>
                </div>
              </notification>
            </div>
          </div>
        </notificationGroup>
  </div>
</div>
		
    
</template>
<script>
import axios from 'axios'
export default {
  name: "App",
  data: () => ({
    statuss: [
        { title: ' ', id: 0 },
        { title: 'Active', id: 1 },
        { title: 'Inactive', id: 2 },
        { title: 'Pending', id: 3 },
        { title: 'Close', id: 4 },                 
    ],
    user_rules: [
        { title: ' ', id: 0 },
        { title: 'Super Admin', id: 1 },
        { title: 'Admin', id: 2},
        { title: 'Manager', id: 3 },
        { title: 'User', id: 4 },                 
    ],
  }),
    methods: {      
    onClickTop() {
      this.$notify(
        {
          group: "top",
          title: "Success",
          text: "Your account was registered!"
        },
        5000
      );
    },
    onClickBot() {
      this.$notify(
        {
          group: "bottom",
          title: "Error",
          text: "Your email is already used! Your email"
        },
        8000
      );
    }
    },
    mounted() {
      axios
        .get('/api/userAccount/UserAccountForm')
        .then(response => {
          this.posts = response.data
          console.log(response.data);
        })
    }
};
</script>
