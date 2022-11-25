<template>
    <div>
      <div role="alert">
        <div class="bg-gray-400 text-white font-bold rounded-t px-4 py-1">
          {{$t('Purchase')}}
        </div>      
      </div>
      <form class="bg-white p-5 rounded-lg shadow-lg min-w-full">
        <div class="flex flex-wrap -mx-2 space-y-4 md:space-y-0">
          <div class="w-full px-2 pt-1 md:w-1/5">            
                <label class="text-gray-800 font-semibold my-3 text-md">{{ $t('Vendor') }}</label>            
          </div>
          <div class="w-full px-2 md:w-1/5"> 
                <input id="border-username" class="w-full h-7 pl-2 pr-2 text-sm rounded-lg focus:outline-none border-solid border" disabled v-model="branch.name" type="text" autocomplete="off"/> 
          </div>  
          <div class="w-full px-2 pt-1 md:w-1/5"></div> 
          <div class="w-full px-2 pt-1 md:w-1/5">            
                <label class="text-gray-800 font-semibold my-3 text-md">{{ $t('InvoiceNº') }}</label>
          </div> 
          <div class="w-full px-2 md:w-1/5"> 
                <input id="border-username" class="w-full h-7 pl-2 pr-2 text-sm rounded-lg focus:outline-none border-solid border" disabled v-model="branch.name" type="text" autocomplete="off"/>            
          </div>                 
        </div>  
        <div class="flex flex-wrap -mx-2 pt-1 space-y-4 md:space-y-0">
          <div class="w-full px-2 pt-1 md:w-1/5">            
                <label class="text-gray-800 font-semibold my-3 text-md">{{ $t('Branch') }}</label>            
          </div>
          <div class="w-full px-2 md:w-1/5"> 
                <input id="border-username" class="w-full h-7 pl-2 pr-2 text-sm rounded-lg focus:outline-none border-solid border" disabled v-model="branch.name" type="text" autocomplete="off"/> 
          </div>  
          <div class="w-full px-2 pt-1 md:w-1/5"></div> 
          <div class="w-full px-2 pt-1 md:w-1/5">            
                <label class="text-gray-800 font-semibold my-3 text-md">{{ $t('Number') }}</label>
          </div> 
          <div class="w-full px-2 md:w-1/5"> 
                <input id="border-username" class="w-full h-7 pl-2 pr-2 text-sm rounded-lg focus:outline-none border-solid border" disabled v-model="branch.name" type="text" autocomplete="off"/>            
          </div>                 
        </div>  
        <div class="flex flex-wrap -mx-2 space-y-4 pt-1 md:space-y-0">
          <div class="w-full px-2 pt-1 md:w-1/5">            
                <label class="text-gray-800 font-semibold  my-3 text-md">{{ $t('Vendor Ref No.') }}</label>            
          </div>
          <div class="w-full px-2 md:w-1/5"> 
                <input id="border-username" class="w-full h-7 pl-2 pr-2 text-sm rounded-lg focus:outline-none border-solid border" v-model="branch.name" type="text" autocomplete="off"/> 
          </div> 
          <div class="w-full px-2 pt-1 md:w-1/5"></div> 
          <div class="w-full px-2 pt-1 md:w-1/5">            
                <label class="text-gray-800 font-semibold my-3 text-md">{{ $t('Status') }}</label>
          </div> 
          <div class="w-full px-2 md:w-1/5"> 
                <input id="border-username" class="w-full h-7 pl-2 pr-2 text-sm rounded-lg focus:outline-none border-solid border" disabled v-model="branch.name" type="text" autocomplete="off"/>            
          </div>                 
        </div>  
        <div class="flex flex-wrap -mx-2 space-y-4 pt-1 md:space-y-0">
          <div class="w-full px-2 pt-1 md:w-1/5">            
                <label class="text-gray-800 font-semibold my-3 text-md">{{ $t('Creator') }}</label>            
          </div>
          <div class="w-full px-2 md:w-1/5"> 
                <input id="border-username" class="w-full h-7 pl-2 pr-2 text-sm rounded-lg focus:outline-none border-solid border" disabled v-model="branch.name" type="text" autocomplete="off"/> 
          </div>  
          <div class="w-full px-2 pt-1 md:w-1/5"></div> 
          <div class="w-full px-2 pt-1 md:w-1/5">            
                <label class="text-gray-800 font-semibold my-3 text-md">{{ $t('Posting Date') }}</label>
          </div> 
          <div class="w-full px-2 md:w-1/5"> 
                <input id="border-username" class="w-full h-7 pl-2 pr-2 text-sm rounded-lg focus:outline-none border-solid border" v-model="branch.name" type="date" autocomplete="off"/>            
          </div>                 
        </div>                
      </form>   
    <v-card>
      <!-- exchangerate -->
        <table>
              <tr>
                <th>No.</th>
                <th>System Currency</th>
                <th>To</th>
                <th>Exchage</th>
                <th>Rate</th>
                <th>Amount</th>
                <th>Action</th>
              </tr>
              <tr v-for="(item , index) in exrate" :key="index">
                <td>{{index +1}}</td>
                <td>{{comp[0].scName}}</td>
                <td>⇒</td>
                <td>{{item.currName}}</td>
                <td><input type="number" v-model="item.rate1"/></td>
                <td><input /></td>
                <td><v-icon small color="red lighten-2" @click="deleteItem(item)">mdi-delete</v-icon></td>
              </tr>  
            </table> 
            <div class="flex flex-wrap -mx-2 space-y-4 md:space-y-0">
          <div class="w-full px-2 pt-7 md:w-1/2 flex space-x-4">
            <div>
              <button type="button" @click="saveData" class="px-4 py-1.5 bg-blue-600 font-medium text-xs leading-tight rounded shadow-md hover:bg-blue-700 hover:shadow-lg focus:bg-blue-700 focus:shadow-lg focus:outline-none focus:ring-0 active:bg-blue-800 active:shadow-lg transition duration-150 ease-in-out" style="color: white">{{$t('Save')}}</button>
            </div>
            <div>
              <button type="button" @click="clearData" class="px-4 py-1.5 bg-yellow-600 font-medium text-xs leading-tight rounded shadow-md hover:bg-yellow-700 hover:shadow-lg focus:bg-yellow-700 focus:shadow-lg focus:outline-none focus:ring-0 active:bg-blue-800 active:shadow-lg transition duration-150 ease-in-out" style="color: white">{{$t('Clear')}}</button>
            </div>
          </div>
        </div> 
    </v-card>

      <!-- notificationGroup -->
      <div class="text-center">
        <notificationGroup group="top">
          <div class="fixed inset-0 top-20 z-50 flex px-4 py-6 pointer-events-none p-6 items-start justify-end">
            <div class="max-w-sm">
              <notification v-slot="{notifications}">
                <div class="flex max-w-sm w-full mx-auto bg-white shadow-md rounded-lg overflow-hidden mt-4"
                     v-for="notification in notifications"
                     :key="notification.id">
                  <div class="flex justify-center items-center w-12 bg-green-500">
                    <svg class="h-6 w-6 fill-current text-white"
                         viewBox="0 0 40 40"
                         xmlns="http://www.w3.org/2000/svg">
                      <path d="M20 3.33331C10.8 3.33331 3.33337 10.8 3.33337 20C3.33337 29.2 10.8 36.6666 20 36.6666C29.2 36.6666 36.6667 29.2 36.6667 20C36.6667 10.8 29.2 3.33331 20 3.33331ZM16.6667 28.3333L8.33337 20L10.6834 17.65L16.6667 23.6166L29.3167 10.9666L31.6667 13.3333L16.6667 28.3333Z"></path>
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
      <div class="vt-bot fixed inset-x-2 bottom-5 z-50 flex px-4 py-6 pointer-events-none p-4 items-start justify-end">
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
                  <p class="text-gray-600 text-sm"><span class="text-red-500 font-semibold">{{notification.title}}</span> {{notification.text}}</p>
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
        branch:[],
        currobj:[],
        exrate:{},
      }),
      methods: {

      },
      mounted() {      
      getexRate(axios,this)
      getCurrency(axios,this)      
      },
    };
    function getCurrency(axios, _this){
      axios.get('/api/company/GetCurrency')
      .then(response => {         
        _this.currobj = response.data.currencies;                     
      })
    }
    function getexRate(axios, _this){
      axios.get('/api/company/GetExchangeRate').then(response => {         
        _this.exrate = response.data.exchange;
        _this.comp = response.data.company;               
      });
    }
  </script>
  <style scoped>
    .v-slide-group__wrapper {
      height: 35px !important;
    }
    table {
      font-family: arial, sans-serif;
      /* border-collapse: collapse; */
      width: 100%;
    }
    td, th {
      border: 1px solid #dddddd;
      text-align: left;
      padding: 3px;
    }
    tr:nth-child(even) {
      background-color: #dddddd;
    }
    </style>
  