<template>
  <q-page class="q-pa-md row items-start q-gutter-md ">
    <q-card>
      <q-card-section>
        <div class="text-h6 text-grey-8 text-weight-bolder">
          Eventos por sensor
        </div>
      </q-card-section>
      <q-card-section class="q-pa-none echarts">
        <IEcharts :option="barChartOption.eventsBySensor" :resizable="true" />
      </q-card-section>
    </q-card>
    <q-card>
      <q-card-section>
        <div class="text-h6 text-grey-8 text-weight-bolder">
          Eventos por região
        </div>
      </q-card-section>
      <q-card-section class="q-pa-none echarts">
        <IEcharts :option="barChartOption.eventsByRegion" :resizable="true" />
      </q-card-section>
    </q-card>
  </q-page>
</template>

<script>
import IEcharts from 'vue-echarts-v3/src/full.js'
import { mapGetters } from 'vuex'
import axiosInstance from 'axios'

export default {
  name: 'Events',
  data () {
    return {
      barChartOption: {
        eventsBySensor: {
          grid: {
            bottom: '50%'
          },
          animation: false,
          legend: {},
          tooltip: {},
          dataset: {
            dimensions: ['label', 'events'],
            source: {} // this.events.eventsBySensor
          },
          xAxis:
            {
              type: 'category',
              axisLabel: {
                rotate: 90
              }
            },
          yAxis: {},
          // Declare several bar series, each will be mapped
          // to a column of dataset.source by default.
          series: [
            { type: 'bar' }
          ]
        },
        eventsByRegion: {
          grid: {
            bottom: '50%'
          },
          animation: false,
          legend: {},
          tooltip: {},
          dataset: {
            dimensions: ['label', 'events'],
            source: {} // this.events.eventsByRegion
          },
          xAxis:
            {
              type: 'category',
              axisLabel: {
                rotate: 90
              }
            },
          yAxis: {},
          // Declare several bar series, each will be mapped
          // to a column of dataset.source by default.
          series: [
            { type: 'bar' }
          ]
        }
      }
    }
  },
  mounted () {
    const self = this
    const time = 1000

    const loadEvents = function () {
      let eventsByRegion = {}
      let eventsBySensor = {}
      axiosInstance.get('https://localhost:32770/report', {
        headers: {
          'Content-type': 'application/json'
        }
      }).then((response) => {
        eventsByRegion = response.data.eventsByRegion
        eventsBySensor = response.data.eventsBySensor

        if (self.barChartOption !== undefined) {
          self.barChartOption.eventsBySensor.dataset.source = eventsBySensor
          self.barChartOption.eventsByRegion.dataset.source = eventsByRegion
        }
      })
    }

    loadEvents()

    window.timerId = setInterval(loadEvents, time)
  },
  destroyed () {
    window.clearInterval(window.timerId)
  },
  computed: {
    ...mapGetters('events', ['events'])
  },
  components: {
    IEcharts
  }
}
</script>
<style scoped>
  .echarts {
    width: 460px;
    height: 400px;
  }
</style>
