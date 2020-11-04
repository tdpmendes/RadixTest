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
          Eventos por Região
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
            dimensions: ['device', 'events'],
            source: [
              { device: 'brasil.sudeste.sensor01', events: 700 },
              { device: 'brasil.sudeste.sensor02', events: 300 }
            ]
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
            dimensions: ['device', 'events'],
            source: [
              { device: 'brasil.sudeste', events: 1000 },
              { device: 'brasil.sul', events: 1500 }
            ]
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
