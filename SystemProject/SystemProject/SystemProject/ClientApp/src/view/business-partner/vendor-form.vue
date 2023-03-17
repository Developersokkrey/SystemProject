<template>
    <div>
      <div role="alert">
        <div class="bg-gray-400 text-white font-bold rounded-t px-4 py-1">
          {{$t('Vendor')}}
        </div>      
      </div>
      <form class="bg-white p-5 rounded-lg shadow-lg min-w-full">
        <div class="flex flex-wrap -mx-2 space-y-4 md:space-y-0">
          <div class="w-full px-2 md:w-1/2">
            <label class="text-gray-800 font-semibold block my-3 text-md">{{ $t('Code') }}</label>
            <input id="border-username" class="w-full h-8 px-2 text-sm rounded-lg focus:outline-none border-solid border" v-model="vendor.code" type="text" :placeholder="$t('Code')" autocomplete="off"/>
          </div>
          <div class="w-full px-2 md:w-1/2">
            <label class="text-gray-800 font-semibold block my-3 text-md">{{ $t('Phone') }}</label>
            <input id="border-username" class="w-full h-8 px-2 text-sm rounded-lg focus:outline-none border-solid border" v-model="vendor.phone" type="text" :placeholder="$t('Phone')" autocomplete="off"/>
          </div>
          <div class="w-full px-2 md:w-1/2">
            <label class="text-gray-800 font-semibold block my-3 text-md">{{ $t('Name 1') }}</label>
            <input id="border-username" class="w-full h-8 px-2 text-sm rounded-lg focus:outline-none border-solid border" v-model="vendor.name1" type="text" :placeholder="$t('Name 1')" autocomplete="off"/>
          </div>
          <div class="w-full px-2 md:w-1/2">
            <label class="text-gray-800 font-semibold block my-3 text-md">{{$t('Address')}}</label>
            <input id="border-confirm" class="w-full h-8 px-2 text-sm rounded-lg focus:outline-none border-solid border" v-model="vendor.address" type="text" :placeholder="$t('Addtress')" autocomplete="off" />
          </div>
        </div>
        <div class="flex flex-wrap -mx-2 space-y-4 md:space-y-0">
          <div class="w-full px-2 md:w-1/2">
            <label class="text-gray-800 font-semibold block my-3 text-md">{{$t('Name 2')}}</label>
            <input id="border-password" class="w-full h-8 px-2 text-sm rounded-lg focus:outline-none border-solid border" v-model="vendor.name2" type="text" :placeholder="$t('Name 2')" autocomplete="off" />
          </div>
          <div class="w-full px-2 md:w-1/2">
            <label class="text-gray-800 font-semibold block my-3 text-md">{{$t('Location')}}</label>
            <input id="border-confirm" class="w-full h-8 px-2 text-sm rounded-lg focus:outline-none border-solid border" v-model="vendor.location" type="text" :placeholder="$t('Location')"  autocomplete="off"/>
          </div>
        </div>      
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
      </form>
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
        vendor:[],
      }),
      methods: {
        saveData() {        
          let _this = this;        
          axios.post('/api/vendor/CreateVendor/vendor', this.vendor).then((response) => {          
            let message = response.data.data;          
            if (response.data.isRejected == true) {   
              var keys = Object.getOwnPropertyNames(message);
              let msg = "";
              var error_title = ""
              for (let i = 0; i < keys.length; i++) {
                let errors = (typeof message[keys[i]] === "string") ? message[keys[i]].split("/") : ["", ""];
                if (this._i18n.locale == 'en-US') {
                  error_title = "Erorr :";
                  msg = errors[0];
                }
                else if (this._i18n.locale == 'zh-TW') {
                  error_title = "កំហុស​ :";
                  msg = errors[1];
                }
                _this.$notify(
                  {
                    group: "bottom",
                    title: error_title,
                    text: msg
                  },
                  10000
                );
              }         
            }
            else {    
              var error_title = ""
              var keys = Object.getOwnPropertyNames(message);
              let msg = "";
              let errors = (typeof message[keys] === "string") ? message[keys].split("/") : ["", ""];
              if (this._i18n.locale == 'en-US') {
                error_title = "Success :";
                msg = errors[0];
              }
              else if (this._i18n.locale == 'zh-TW') {
                error_title = "ជោគជ័យ​";
                msg = errors[1];
              }
              this.$notify(
                {
                  group: "top",
                  title: error_title,
                  text: msg
                },
                5000
              );
              clearData();      
            }        
          }); 
        },
        clearData() { 
          const _this = this;      
          localStorage.setItem('vendorId', JSON.stringify(0));  
          var vendorId = localStorage.getItem('vendorId');      
          axios.get('/api/vendor/GetVendorEdit',{params:{vendorId: vendorId}}).then(response => {           
            _this.vendor = response.data;         
        })
        }
      },
      mounted() {
        const _this = this; 
        var vendorId = localStorage.getItem('vendorId');   
        axios
        .get('/api/vendor/GetVendorEdit',{params:{vendorId: vendorId}}).then(response => {           
            _this.vendor = response.data;            
        })
      },
    };
  </script>
  