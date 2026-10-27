# Console RPG em C#
## Arquitetura das classes
- Program.cs: Base responsável por executar o início do código e definir cor padrão do console
  
- Menu.cs: Responsável pelo menu inicial de interação. Abriga a opção de "jogar", "opções" e "sair"
  
- Scenary.cs: Executa a campanha interativa do Player. Responsável por exibir os textos, escolhas, interações, cenários e partes principais do jogo para o Player
  
- UI.cs: Compartimento das ferramentas e engrenagens. Métodos como rolamento de dados, alteração de cor do console, sistema de combate pertencem a esta classe
  
- Player/Enemy/Itens: Fornecem atributos e identificação de cada objeto

Este projeto foi concebido como um laboratório prático focado no aprendizado de fundamentos de Orientação a Objetos (OOP), higienização de código e aplicação do Princípio da Responsabilidade Única (SRP)
