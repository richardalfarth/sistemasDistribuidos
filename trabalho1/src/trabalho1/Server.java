/*
 * Autores
 * Rennã Tiedt
 * Richard Curbani Alfarth * 
 * 
 * */

package trabalho1;

import java.io.IOException;
import java.io.InputStream;
import java.io.ObjectInputStream;
import java.io.ObjectOutputStream;
import java.io.OutputStream;
import java.net.ServerSocket;
import java.text.SimpleDateFormat;
import java.util.Date;


public class Server {

	public static void main(String[] args) throws IOException {
		ServerSocket serverSocket = new ServerSocket(1600);
		Date now = new Date();
		//Socket client = server.accept();
		//String pergunta = "Você deseja saber a [1]-Data ou a [2]-Hora?"; 
	    do {
	    	System.out.println("Aguardando conexão...!");
	    	java.net.Socket socket = serverSocket.accept();
	    	System.out.println("Conexão aceita");
	    	ObjectOutputStream saida = new ObjectOutputStream(socket.getOutputStream());
	    	ObjectInputStream input = new ObjectInputStream(socket.getInputStream());
	    	int dado = 0;
	    	String data = new SimpleDateFormat("dd/MM/yyyy").format(now);
	    	String hora = new SimpleDateFormat("HH:mm:ss").format(now);
	    	do {
	    		dado = input.read();
	    		if(dado == 1) {
	    			System.out.println("Data: " + data);
	    			saida.writeUTF(data);
		    		saida.flush();
	    			
	    		}
	    		if(dado == 2) {
	    			System.out.println("Hora: "+hora);
	    			saida.writeUTF(hora);
		    		saida.flush();
	    		}
	    		if(dado == 3) {
	    			saida.flush();
	    		}
	    	}while(dado > -1);
	    	socket.close();
	    	System.out.println("Server Desconectado. ");
	    }while (true);
	}
}
