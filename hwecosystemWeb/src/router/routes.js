import AuthenticationLayout from 'layouts/AuthenticationLayout.vue';
import MainLayout from 'layouts/MainLayout.vue';
import index from 'pages/home/index.vue';
import aboutus from 'pages/home/aboutus.vue';
import streams from 'pages/home/services.vue';
import teams from 'pages/home/teams.vue';
import contribute from 'pages/contribution/contribute.vue';
import dashboard from 'pages/dashboard/dashboard.vue';
import faq from 'pages/dashboard/faq.vue';
import AdminLayout from 'layouts/AdminLayout.vue';
import adminIndex from 'pages/home/index.vue';
import unconfirmedAccounts from 'pages/administrators/AccountAdmin/unconfirmedAccounts.vue';
import confirmPishonLevel from 'pages/administrators/AccountAdmin/confirmPishonLevel.vue';
import registeredContributors from 'pages/administrators/registeredContributors.vue';
import register from 'pages/authentication/register.vue';
import comfirmpayment from 'pages/administrators/AccountAdmin/comfirmpayment.vue';
import indexRefugeCenter from 'pages/administrators/refugeCenter/index.vue';
import leaveRefugeeCenter from 'pages/administrators/refugeCenter/leaveRefugeeCenter.vue';
import indexPishonStream from 'pages/administrators/pishonStream/index.vue';
import confirmedContributors from 'pages/administrators/refugeCenter/confirmedContributors.vue';
import confirmLevel from 'pages/administrators/pishonStream/confirmLevel.vue';
import SelectedStreamLevel from 'pages/administrators/pishonStream/SelectedStreamLevel.vue';
import SelectedStreamLevelNotPaid from 'pages/administrators/AccountAdmin/SelectedStreamLevelNotPaid.vue';
import Error404 from 'pages/Error404.vue';

const routes = [
  { path: '/', component: AuthenticationLayout },
  {
    path: '/home',
    component: MainLayout,
    children: [
      { path: '/home', component: index },
      { path: '/about', component: aboutus },
      { path: '/streams', component: streams },
      { path: '/team', component: teams },
      { path: '/contribution', component: contribute },
      { path: '/dashboard', component: dashboard },
      { path: '/faqs', component: faq }
    ]
  },
  {
    path: '/admin',
    component: AdminLayout,
    children: [
      { path: '/admin', component: adminIndex },
      { path: '/confirmEntryPayment', component: unconfirmedAccounts },
      { path: '/confirmPishonLevelPayment', component: confirmPishonLevel },
      { path: '/registeredContributors', component: registeredContributors },
      { path: '/register', component: register },
      { path: '/comfirmPayment', component: comfirmpayment },
      { path: '/refugecenter', component: indexRefugeCenter },
      { path: '/toPishon', component: leaveRefugeeCenter },
      { path: '/pishonContributors', component: indexPishonStream },
      { path: '/confirmedContributors', component: confirmedContributors },
      { path: '/confirmPishonLevel', component: confirmLevel },
      { path: '/selectedStreamLevel', component: SelectedStreamLevel },
      { path: '/selectedPishonStreamLevelNotPaid', component: SelectedStreamLevelNotPaid }
    ]
  }
]

// Always leave this as last one
if (process.env.MODE !== 'ssr') {
  routes.push({
    path: '*',
    component: Error404
  })
}

export default routes
