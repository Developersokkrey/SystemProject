<template>
<div id="app">
  <div role="alert">
      <div class="bg-gray-400 text-white font-bold rounded-t px-4 py-0.5 w-full flex">
        <div class="w-full md:w-2/2 flex">
          {{$t('Exchange Rate')}}
        </div>
         <!-- <div class="w-full md:w-2/2 flex">           
          <input v-model="search" class="placeholder:italic text-gray-600 font-normal bg-white w-full border border-slate-300 rounded-md pt-0.5 pl-9 pr-3 shadow-sm focus:outline-none focus:border-sky-500 focus:ring-sky-500 focus:ring-1 sm:text-sm" placeholder="Search..." type="text" name="search"/>
        </div> -->
      </div>            
    </div>
  <v-app id="inspire">
    <v-card>
      <v-toolbar height="0" dense color="grey lighten-4" >  
        <template v-slot:extension>
          <v-tabs v-model="tabs">
            <v-tab class="text-capitalize">
              {{ $t('Exchange Rate') }}
            </v-tab>
             <v-tab class="text-capitalize">
              {{ $t('currency') }}
            </v-tab>
          </v-tabs>
        </template>
      </v-toolbar>  
      <v-tabs-items v-model="tabs">        
        <v-tab-item>
          <v-card>
            <!-- exchangerate -->
            <table>
              <tr>
                <th>No.</th>
                <th>System Currency</th>
                <th>To</th>
                <th>Exchage</th>
                <th>Rate</th>
              </tr>
              <tr v-for="(item , index) in exrate" :key="index">
                <td>{{index +1}}</td>
                <td>{{comp[0].scName}}</td>
                <td>⇒</td>
                <td>{{item.currName}}</td>
                <td><input type="number" v-model="item.rate1"/></td>
              </tr>  
            </table> 
            <div class="px-4 py-1.5">
              <button type="button" @click="saveRate" class="px-4 py-1.5 bg-blue-600 font-medium text-xs leading-tight rounded shadow-md hover:bg-blue-700 hover:shadow-lg focus:bg-blue-700 focus:shadow-lg focus:outline-none focus:ring-0 active:bg-blue-800 active:shadow-lg transition duration-150 ease-in-out" style="color: white">{{$t('Save')}}</button>
            </div>          
          </v-card>          
        </v-tab-item>
        <v-tab-item>
          <v-card flat>
            <v-app id="inspire">
              <v-data-table :headers="headers" :items="currobj" sort-by="calories" class="elevation-1" fixed-header height="350" dense>
                <template v-slot:top>
                  <v-toolbar  flat>
                    <v-toolbar-title>My CRUD</v-toolbar-title> 
                    <v-divider class="mx-4" inset vertical></v-divider>
                    <v-spacer></v-spacer>
                    <v-dialog v-model="dialog" max-width="500px">
                      <template v-slot:activator="{ on, attrs }">
                        <v-btn color="primary"  dark class="mb-2" v-bind="attrs" v-on="on">
                          New Currency
                        </v-btn>
                      </template>
                      <v-card>
                        <v-card-title>
                          <span class="text-h5">{{ formTitle }}</span>
                        </v-card-title>            
                        <v-card-text>
                          <v-container>
                            <v-row>
                              <v-col cols="12" sm="6" md="6">
                                <v-text-field v-model="currency.name" label="Currency name"></v-text-field>
                              </v-col>
                              <v-col cols="12" sm="6" md="6">
                                <v-text-field v-model="currency.des" label="Description"></v-text-field>
                              </v-col>
                              <v-col cols="12" sm="6" md="6">
                                <v-text-field v-model="currency.symbol" label="Symbol"></v-text-field>
                              </v-col>
                              <v-col cols="12" sm="6" md="6">                                
                                <v-select label="Status" :items="statuss" v-model="currency.status" item-text="title" item-value="status"></v-select>
                              </v-col>                              
                            </v-row>
                          </v-container>
                        </v-card-text>            
                        <v-card-actions>
                          <v-spacer></v-spacer>
                          <v-btn color="blue darken-1" text @click="close">
                            Cancel
                          </v-btn>
                          <v-btn color="blue darken-1" text @click="save">
                            Save
                          </v-btn>
                        </v-card-actions>
                      </v-card>
                    </v-dialog>
                    <v-dialog v-model="dialogDelete" max-width="500px">
                      <v-card>
                        <v-card-title class="text-h5">Are you sure you want to delete this item?</v-card-title>
                        <v-card-actions>
                          <v-spacer></v-spacer>
                          <v-btn color="blue darken-1" text @click="closeDelete">Cancel</v-btn>
                          <v-btn color="blue darken-1" text @click="deleteItemConfirm">OK</v-btn>
                          <v-spacer></v-spacer>
                        </v-card-actions>
                      </v-card>
                    </v-dialog>
                  </v-toolbar>
                </template>
                <template v-slot:item.actions="{ item }">
                  <v-icon small class="mr-2" @click="editItem(item)" color="indigo">
                    mdi-pencil
                  </v-icon>
                  <v-icon small @click="deleteItem(item)" color="red lighten-2">
                    mdi-delete
                  </v-icon>
                </template>                
              </v-data-table>
            </v-app>
          </v-card>
        </v-tab-item>
      </v-tabs-items>
    </v-card>
  </v-app>
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
  export default ({
  data: () => ({
      exrate:{},
      comp:{},
      tabs: null,
      text: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.',
      dialog: false,
      dialogDelete: false,
      headers: [ 
        { text: 'Currency Name', value: 'name' },
        { text: 'Description', value: 'des' },
        { text: 'Symbol', value: 'symbol' },
        { text: 'Status', value: 'statusName' },
        { text: 'Actions', value: 'actions', sortable: false },
      ],
      desserts: [],
      editedIndex: -1,
      editedItem: {
        name: '',
        calories: '',
        fat: '',
        carbs: '',
        protein: '',
      },
      defaultItem: {
        name: '',
        calories: 0,
        fat: 0,
        carbs: 0,
        protein: 0,
      },
      statuss: [
                  { title: ' ', status: 0 },
                  { title: 'Active', status: 1 },
                  { title: 'Inactive', status: 2 },
              ],
      currobj:[],
      userStatus:{},
      currency:{
        id: '0',
        name: '',
        des: '',
        symbol: '',
        status: 0,
        comid: '1',
      },      
    }),

    computed: {
      formTitle () {
        return this.editedIndex === -1 ? 'Add Currency' : 'Edit Currency'
      },      
    },    
    watch: {      
      dialog (val) {  
          val || this.open()
      },
      dialogDelete (val) {
        val || this.closeDelete()
      },
    },
    created () {
      this.initialize()
    },
    methods: {      
      editItem (item) {
        this.editedIndex = this.desserts.indexOf(item)
        this.editedItem = Object.assign({}, item)
        this.dialog = true
      },

      deleteItem (item) {
        this.editedIndex = this.desserts.indexOf(item)
        this.editedItem = Object.assign({}, item)
        this.dialogDelete = true
      },

      deleteItemConfirm () {
        this.desserts.splice(this.editedIndex, 1)
        this.closeDelete()
      },

      close () {
        this.dialog = false
        this.$nextTick(() => {
          this.editedItem = Object.assign({}, this.defaultItem)
          this.editedIndex = -1
        })
      },
      closeDelete () {
        this.dialogDelete = false
        this.$nextTick(() => {
          this.editedItem = Object.assign({}, this.defaultItem)
          this.editedIndex = -1
        })
      },
      save () { 
        let _this = this;      
          console.log(this.currency)   
          axios.post('/api/company/CreateCurrency', this.currency).then((response) => { 
            let message = response.data.data;
            if (response.data.isRejected == true) {              
            }
            else {  
              var error_title = ""
              var keys = Object.getOwnPropertyNames(message);
              let msg = "";
              let errors = (typeof message[keys] === "string") ? message[keys].split("/") : ["", ""];
              if (this._i18n.locale == 'en-US') {
                error_title = "Success";
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
              this.close()
              getCurrency(axios,this)
              getexRate(axios,this)
            }
          });         
      },
      saveRate(){ 
          axios.post('/api/company/SaveRate/exchange', this.exrate).then((response) => {            
            let message = response.data.data;
            if (response.data.isRejected == true) {            
            }
            else {           
              var error_title = ""
              var keys = Object.getOwnPropertyNames(message);
              let msg = "";
              let errors = (typeof message[keys] === "string") ? message[keys].split("/") : ["", ""];
              if (this._i18n.locale == 'en-US') {
                error_title = "Success";
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
            }
          });  
      },   
    }, 
    mounted() {      
      getexRate(axios,this)
      getCurrency(axios,this)
      localStorage.setItem('exDialog', JSON.stringify(0));
    },
    })    
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
