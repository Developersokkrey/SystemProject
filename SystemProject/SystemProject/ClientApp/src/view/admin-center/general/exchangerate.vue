<template>
<div id="app">
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
            <v-card-title class="headline">An even better title</v-card-title>
            <v-card-text>
              <p>
                5Maecenas ullamcorper, dui et placerat feugiat, eros pede varius nisi, condimentum viverra felis nunc et lorem. Sed hendrerit. Maecenas malesuada. Vestibulum ullamcorper mauris at ligula. Proin faucibus arcu quis ante.
              </p>  
              <p class="mb-0">
                5Etiam vitae tortor. Curabitur ullamcorper ultricies nisi. Sed magna purus, fermentum eu, tincidunt eu, varius ut, felis. Aliquam lobortis. Suspendisse potenti.
              </p>
            </v-card-text> 
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
                <!-- <template v-slot:no-data>
                  <v-btn color="primary" @click="initialize">
                    Reset
                  </v-btn>
                </template> -->
              </v-data-table>
            </v-app>
          </v-card>
        </v-tab-item>
      </v-tabs-items>
    </v-card>
  </v-app>
</div>
</template>
<script>
  import axios from 'axios' 
  export default ({
  data: () => ({
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
        id: 0,
        name: '',
        des: '',
        symbol: '',
        status: 0,
        comid: 1,
      }
    }),

    computed: {
      formTitle () {
        return this.editedIndex === -1 ? 'Add Currency' : 'Edit Currency'
      },
    },

    watch: {
      dialog (val) {
        val || this.close()
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
        console.log(this.currency)
        // if (this.editedIndex > -1) {
        //   Object.assign(this.desserts[this.editedIndex], this.editedItem)
        // } else {
        //   this.desserts.push(this.editedItem)
        // }
        // this.close()  
        let _this = this;         
          axios.post('/api/company/Currency/currency', this.currency).then((response) => { 
            if (response.data.isRejected == true) {
              
            }
            else {
              //this.currency.push(this.currency)
              this.close()
            }
          });      
        // if(this.currency > -1){
                  
        
        // } else {
        //    this.currency.push(this.currency)
        // }
        // this.close()
      },    
    }, 
    mounted() {
      const _this = this;
      axios
      .get('/api/company/GetCurrency')
      .then(response => {         
        _this.currobj = response.data.currencies;
       console.log(response.data.currencies)
        //console.log(response.data)
      })
    },
    })
    function dialogform(enabled = true){
        dialog = true;
    }
</script>
