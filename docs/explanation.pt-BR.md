# ⚡ Parallelism and concurrency

## SynchronizationContext

Ambiente no qual uma determinada tarefa (Task / Thread) é executada

Evitar que ocorra deadlocks.

Outros itens de sincronização:

- locks, semáforos ou mutex

## Uso do `.Result` em operações assíncronas

- Bloqueia a thread original até a tarefa ser concluída
- A ideia por trás do async/await é liberar a thread original para que ela possa realizar outras tarefas enquanto a operação assíncrona é executada
