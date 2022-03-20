<template>
  <v-simple-table>
    <template>
      <thead>
        <tr>
          <th class="text-uppercase">
            UserId
          </th>
          <th class="text-center text-uppercase">
            ID
          </th>
          <th class="text-center text-uppercase">
            Title
          </th>
          <th class="text-center text-uppercase">
            Boby
          </th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="post in posts" :key="posts.id">
          <td>{{ post.userId }}</td>
          <td class="text-center">
            {{ post.id }}
          </td>
          <td class="text-center">
            {{ post.title}}
          </td>
          <td class="text-center">
            {{ post.body }}
          </td>          
        </tr>
      </tbody>
    </template>
  </v-simple-table>
</template>

<script>
import axios from 'axios'
export default {
  name: "Home",
   data() {
     return {
        posts: []
     }
   },
   methods: {
     
   }, 
   mounted(){
     axios
     .get('https://jsonplaceholder.typicode.com/posts')
     .then(response => {
       this.posts = response.data
     })
   }
}
</script>

