package trabalho1_client;

import java.io.IOException;
import java.io.ObjectInputStream;
import java.io.ObjectOutputStream;
import java.net.InetSocketAddress;
import java.net.ServerSocket;
import java.net.Socket;

public class Client {
	public static void main(String[] args) throws IOException {
		Socket socket = new Socket("localhost",1600);
		ObjectOutputStream output = new ObjectOutputStream(socket.getOutputStream());
		ObjectInputStream input = new ObjectInputStream(socket.getInputStream());
		System.out.println("Você deseja saber a [1]-Data ou a [2]-Hora?");
		//System.out.println(input.read());
		int dado = 2;
		output.write(2);
		output.flush();
		
		System.out.println("Resposta: " + input.readUTF());
		
		input.close();
		output.close();
		socket.close();
	}
}