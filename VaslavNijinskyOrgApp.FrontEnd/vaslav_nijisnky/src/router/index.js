// VIEWS
import HomeView from '@/views/HomeView.vue'
import ChoreographiesView from '../views/ChoreographiesView.vue'
import ParticipantsView from '../views/ParticipantsView.vue'
import SchoolsView from '../views/SchoolsView.vue'
import AddChoreography from '../views/AddChoreography.vue'
import AddParticipant from '../views/AddParticipant.vue'
import AddSchool from '../views/AddSchool.vue'
import EditChoreography from '../views/EditChoreography.vue'
import EditParticipant from '../views/EditParticipant.vue'
import EditSchool from '../views/EditSchool.vue'
import EvaluateChoreography from '../views/EvaluateChoreography.vue'

import { createRouter, createWebHashHistory } from 'vue-router'

const routes = [
  {
    path: '/',
    name: 'Home',
    component: HomeView
  },
  {
    path: '/Choreographies',
    name: 'Choreographies',
    component: ChoreographiesView
  },
  {
    path: '/EvaluateChoreography',
    name: 'EvaluateChoreography',
    component: EvaluateChoreography,
    props: true
  },
  {
    path: '/AddChoreography',
    name: 'AddChoreography',
    component: AddChoreography
  },
  {
    path: '/Choreographies/:id',
    name: 'Choreographies_id',
    component: EditChoreography,
    props: true
  },
  {
    path: '/Participants',
    name: 'Participants',
    component: ParticipantsView
  },
  {
    path: '/AddParticipant',
    name: 'AddParticipant',
    component: AddParticipant
  },
  {
    path: '/Participants/:id',
    name: 'Participants_id',
    component: EditParticipant,
    props: true
  },
  {
    path: '/Schools',
    name: 'Schools',
    component: SchoolsView
  },
  {
    path: '/AddSchool',
    name: 'AddSchool',
    component: AddSchool
  },
  {
    path: '/Schools/:id',
    name: 'Schools_id',
    component: EditSchool,
    props: true
  }
  
]

const router = createRouter({
  history: createWebHashHistory(),
  routes
})

export default router
