<template>
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
    <td><input v-model="item.rate1"/></td>
  </tr>  
</table>
</template>

<script>
import axios from 'axios'  
export default {
  data: () =>({
    exrate:[],
    comp:{},
  }),
  mounted() {
     axios.get('/api/company/GetExchangeRate').then(response => { 
        this.exrate = response.data.exchange;
        this.comp = response.data.company;               
      });   
  },
}
</script>
<style>
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
