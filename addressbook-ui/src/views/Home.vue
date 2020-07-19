<template>
  <div class="home">
    <ContactsGrid />
  </div>
</template>

<script>
import ContactsGrid from '@/components/ContactsGrid.vue';

export default {
  name: 'Home',
  components: {
    ContactsGrid,
  },
};
</script>
