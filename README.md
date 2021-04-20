# DesafioDBSP



A - O DDD, em minhas palavras, é a modelagem de projeto onde os diferentes domínios desta aplicação são representados de forma mais adequada com uma linguagem comum a todos (do dev ao usuário final). Importante tanto para trazer uma visão mais humana do negócio aos desenvolvedores quanto uma experiência menos “sistêmica” aos diferentes tipos de usuários finais.

B - Em uma arquitetura de microsserviços temos responsabilidades descentralizadas dentro do projeto. Esta arquitetura facilita o desenvolvimento no sentido da manutenção ser isolada. O ônus que vejo é a replicação de tabelas de banco de dados que pode ser necessária nos diferentes microsserviços. Além  disso, o mapeamento de todas as comunicações entre os microsserviços que vierem a existir pode ser um desafio.

C - Na comunicação síncrona aguardamos a resposta do método assim denominado. Na comunicação assíncrona, comandamos a execução de um método sem a necessidade de aguardar pelo retorno do mesmo. 
Acredito que o melhor cenário para uso do assíncrono é quando vamos executar uma operação pode poder ser demorada, como um processamento de alguma arquivo txt, ou csv, por exemplo, ou a execução de uma query grande no banco de dados.
Um exemplo do uso do síncrono é quando precisamos do resultado de um método para realizar outro processamento.
