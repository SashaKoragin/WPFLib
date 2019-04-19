export class ServerAndComputer {

    ServerIfns:ServerIfns[];
}


export class ServerIfns  {
    Id: number;
    ServerName: string;
    ServerDiscription: string;
    Children:string;
    ServerIp: string;
    DataCreate: Date;
    Status:string;
}


export class ServerModel {

    //Сборные строки серверов
    app040: string = '';
    app041: string = '';
    app001: string = '';
    app025: string = '';
    app007: string = '';
    app051: string = '';

  private nullable() {
      this.app040 = '';
      this.app041 = '';
      this.app001 = '';
      this.app025 = '';
      this.app007 = '';
      this.app051 = '';
    }

   public select(servers: ServerIfns[]) {
        this.nullable();
        for (var ser of servers) {
            if (ser.Status === 'TimedOut') {
                this.timeOut(ser);
            }
            if (ser.Status === 'DestinationUnreachable') {
                this.destinationUnreachable(ser);
            }
       }
    }

   private destinationUnreachable(servers: ServerIfns) {
       this.model('Не доступен:', servers);  
    }

   private timeOut(servers: ServerIfns) {
       this.model('Не пингуется: ', servers);
    }

  private model(status: string, servers: ServerIfns) {
        if (servers.ServerName === 'i7751-app040' || servers.ServerName === 'i7751-app035' || servers.ServerName === 'i7751-app043' || servers.ServerName === 'i7751-app033') {
            this.app040 += this.app040.concat(`${status + servers.ServerName}; `);
        }
        if (servers.ServerName === 'i7751-app001') {
            this.app041 += this.app041.concat(`${status + servers.ServerName}; `);;
        }
        if (servers.ServerName === 'i7751-app041' || servers.Children === 'i7751-app041') {
            this.app001 += this.app001.concat(`${status + servers.ServerName}; `);;
        }
        if (servers.ServerName === 'i7751-app025') {
            this.app025 += this.app025.concat(`${status + servers.ServerName}; `);;
        }
       if (servers.ServerName === 'i7751-app007' || servers.Children === 'i7751-app007') {
           this.app007 += this.app007.concat(`${status + servers.ServerName}; `);;
        }
        if (servers.ServerName === 'i7751-app051') {
            this.app051 += this.app051.concat(`${status + servers.ServerName}; `);;
        }
    }
    
}