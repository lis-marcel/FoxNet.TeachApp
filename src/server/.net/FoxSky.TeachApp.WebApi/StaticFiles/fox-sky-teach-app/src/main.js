import { createApp } from 'vue';
import App from './App.vue';
import router from './router';

var app = createApp(App)
app.config.globalProperties.$loggedUserId = 1
app.config.globalProperties.$serverUrl = "http://localhost:14512/webapi"

app.use(router).mount('#app')