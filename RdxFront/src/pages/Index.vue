<template>
  <q-page class="flex flex-center">
    <div>
      <h4>Rdx Front</h4>
      <h6>Feito por: <a href="https://github.com/tdpmendes">@tdpmendes</a></h6>
      <p>Esta foi uma aplicação desenvolvida para atender às tarefas propostas no processo seletivo da Radix</p>
      <p>A solução proposta é composta por :</p>
      <ul>
        <li>Um docker com o Sql Server</li>
        <li>Um docker com a Api (Rdx Server)</li>
        <li>Um (ou mais) docker com o robô para envio de eventos (Rdx Device)</li>
        <li>Um docker com o Painel de Relatórios (Rdx Front) feito em <a href="https://quasar.dev/">Quasar</a></li>
      </ul>
      <p>Expanda o menu no canto superior esquerdo e clique em Events para visualizar os Graficos</p>
    </div>
  </q-page>
</template>

<script>
export default {
  name: 'PageIndex'
}
</script>
