Normalmente, na camada de Application também criamos classes que orquestram a interação entre apresentação, dominio eNormalmente, na camada de Application também criamos classes que orquestram a interação entre apresentação, dominio e infraestrutura, as famosas Application Services

As Application Services estou substituindo pelo uso do MediaR, dessa forma são substituídas por Handlers do MediatR que servem ao mesmo propósito. 
Com isso recebemos um request/command e fazemos toda a orquestração para um “use case" específico.