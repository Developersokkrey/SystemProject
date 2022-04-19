<template>
<select v-model="test">
</select>
</template>

<script>
  export default {
    ddata() {
    return{
        test: ['one', 'two', 'three'],
        testVal: null
    }
}
}
</script>