<template>
  <div>
    <form class="bg-white p-5 rounded-lg shadow-lg min-w-full" @keyup.enter="saveData">
      <div class="flex flex-wrap -mx-2 space-y-4 md:space-y-0">
        <div class="w-full px-2 md:w-1/2">
          <label class="text-gray-800 font-semibold block my-3 text-md">{{ $t('Username') }}</label>
          <input id="border-username" class="w-full h-8 px-2 text-sm rounded-lg focus:outline-none border-solid border" v-model="user.username" type="text" :placeholder="$t('Username')" autocomplete="off"/>
        </div>
        <div class="w-full px-2 md:w-1/2">
          <div>
            <label class="text-gray-800 font-semibold block my-3 text-md">{{ $t('Gender')}}</label>
          </div>
          <div class="form-check">
            <input type="radio" v-model="user.gender" id="1" value="1" name="flexRadioDefault">
            <label class="form-check-label inline-block text-gray-800 pl-1 pr-5" for="flexRadioDefault1">
              {{ $t('Male')}}
            </label>
            <input type="radio" v-model="user.gender" id="2" value="2" name="flexRadioDefault">
            <label class="form-check-label inline-block text-gray-800 pl-1 pr-5" for="flexRadioDefault1">
              {{$t('Female')}}
            </label>
            <input type="radio" v-model="user.gender" id="3" value="3" name="flexRadioDefault">
            <label class="form-check-label inline-block text-gray-800 pl-1 pr-5" for="flexRadioDefault1">
              {{$t('Other')}}
            </label>
          </div>
        </div>
      </div>
      <div class="flex flex-wrap -mx-2 space-y-4 md:space-y-0">
        <div class="w-full px-2 md:w-1/2">
          <label class="text-gray-800 font-semibold block my-3 text-md">{{$t('Password')}}</label>
          <input id="border-password" class="w-full h-8 px-2 text-sm rounded-lg focus:outline-none border-solid border" v-model="user.password" type="Password" :placeholder="$t('Password')" />
        </div>
        <div class="w-full px-2 md:w-1/2">
          <label class="text-gray-800 font-semibold block my-3 text-md">{{$t('Confirm Password')}}</label>
          <input id="border-confirm" class="w-full h-8 px-2 text-sm rounded-lg focus:outline-none border-solid border" v-model="user.confirmPassword" type="Password" :placeholder="$t('Confirm Password')" />
        </div>
      </div>
      <div class="flex flex-wrap -mx-2 space-y-4 md:space-y-0">
        <div class="w-full px-2 md:w-1/2">
          <label class="text-gray-800 font-semibold block my-3 text-md">{{$t('Rules')}}</label>
          <select v-model="user.rule" id="border-rule" class="w-full h-8 px-2 text-sm text-gray-700 placeholder-gray-600 border border-solid rounded-lg focus:outline-none">
            <option :value="rule.value" v-for="rule in user_rules" :key="rule.value">{{ rule.title }}</option>
          </select>
        </div>
        <div class="w-full px-2 md:w-1/2">
          <label class="text-gray-800 font-semibold block my-3 text-md" for="email">{{$t('Status')}}</label>
          <select v-model="user.status" id="border-status" class="w-full h-8 px-2 text-sm text-gray-700 placeholder-gray-600 border border-solid rounded-lg focus:outline-none">
            <option :value="status.value" v-for="status in statuss" :key="status.value">{{ status.title }}</option>
          </select>
        </div>
      </div>
      <div class="flex flex-wrap -mx-2 space-y-4 md:space-y-0">
        <div class="w-full px-2 pt-12 md:w-1/2 flex space-x-4">
          <div>
            <button type="button" @click="saveData" class="px-4 py-1.5 bg-blue-600 font-medium text-xs leading-tight rounded shadow-md hover:bg-blue-700 hover:shadow-lg focus:bg-blue-700 focus:shadow-lg focus:outline-none focus:ring-0 active:bg-blue-800 active:shadow-lg transition duration-150 ease-in-out" style="color: white">{{$t('Save')}}</button>
          </div>
          <div>
            <button type="button" @click="clearData" class="px-4 py-1.5 bg-yellow-600 font-medium text-xs leading-tight rounded shadow-md hover:bg-yellow-700 hover:shadow-lg focus:bg-yellow-700 focus:shadow-lg focus:outline-none focus:ring-0 active:bg-blue-800 active:shadow-lg transition duration-150 ease-in-out" style="color: white">{{$t('Clear')}}</button>
          </div>
        </div>
        <div class="w-full px-2 md:w-1/2">
          <label class="text-gray-800 font-semibold block my-3 text-md" for="email">{{$t('Branch')}}</label>
          <select v-model="user.branid" id="border-branch" class="w-full h-8 px-2 text-sm text-gray-700 placeholder-gray-600 border border-solid rounded-lg focus:outline-none">
            <option :value="branobj.id" v-for="branobj in branobjs" :key="branobj.id">{{ branobj.title }}</option>
          </select>
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
      user:{},
      branobjs:[],
      statuss: [
        { title: ' ', value: 0 },
        { title: 'Active', value: 1 },
        { title: 'Inactive', value: 2 },
        { title: 'Pending', value: 3 },
        { title: 'Close', value: 4 },
      ],
      user_rules: [
        { title: ' ', value: 0 },
        { title: 'Super Admin', value: 1 },
        { title: 'Admin', value: 2 },
        { title: 'Manager', value: 3 },
        { title: 'User', value: 4 },
      ],
    }),
    methods: {
      saveData() {
        let _this = this;         
        axios.post('/api/userAccount/CreateUserAccount/userAccount', this.user).then((response) => {
          clearNotify(false);
          let message = response.data.data;
          console.log(response.data.isRejected)
          if (response.data.isRejected == true) {
            if (response.data.data.username != undefined) {
              document.getElementById("border-username").style.borderColor = "red";
            }
            if (response.data.data.password != undefined) {
              document.getElementById("border-password").style.borderColor = "red";
            }
            if (response.data.data.confirmPassword != undefined) {
              document.getElementById("border-confirm").style.borderColor = "red";
            }
            if (response.data.data.rules != undefined) {
              document.getElementById("border-rule").style.borderColor = "red";
            }
            if (response.data.data.status != undefined) {
              document.getElementById("border-status").style.borderColor = "red";
            }
            if (response.data.data.status != undefined) {
              document.getElementById("border-branch").style.borderColor = "red";
            }
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
            localStorage.setItem('usid', JSON.stringify(0));
            var id = localStorage.getItem('usid');            
            //onClickTop();           
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
            resetUser(axios, this);
          }
        });
      },
      clearData() {           
        //clearNotify();        
        //console.log(this.user)
        localStorage.setItem('usid', JSON.stringify(0));        
        resetUser(axios, this);
      }
    },
    mounted() {
      // var testObject = { 'one': 1, 'two': 2, 'three': 3 };
      // // Put the object into storage
      // localStorage.setItem('testObject', JSON.stringify(testObject));
      // Retrieve the object from storage 
      // var usid = localStorage.getItem('usid');
      // console.log('usid: ', JSON.parse(usid));           
      const _this = this;
      resetUser(axios, this); 
    },
  };

  function setBranches(self){
     axios
      .get('/api/branch/GetBranch')
      .then(response => {  
        self.branobjs = response.data;
      });
  }
  function resetUser(axios, self) {
    var id = localStorage.getItem('usid');
    console.log(id);
    document.getElementById("border-username").style.borderColor = "";
    document.getElementById("border-password").style.borderColor = "";
    document.getElementById("border-confirm").style.borderColor = "";
    document.getElementById("border-rule").style.borderColor = "";
    document.getElementById("border-status").style.borderColor = "";
    document.getElementById("border-branch").style.borderColor = "";    
    axios
      .get('/api/userAccount/UserAccountForm/', {params:{usid: id}}).then(response => {
        setBranches(self);
        //this.posts = response.data
        localStorage.setItem('usid', JSON.stringify(0)); 
        let props = Object.getOwnPropertyNames(response.data);
        let _user = Object.assign(response.data);
        for (let i = 0; i < props.length; i++) {
          self.user[props[i]] = _user[props[i]];
        }
        self.user = _user         
      });    
  }

  function clearNotify(enabled = true) {
    let notify = document.getElementsByClassName('vt-bot');
    for (let i = 0; i < notify.length; i++) {
      notify[i].classList.remove("hidden");
      if (enabled) {
        notify[i].classList.add("hidden");
      }      
    }
  }
</script>
