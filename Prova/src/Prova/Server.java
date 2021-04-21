package Prova;

import java.io.DataInputStream;
import java.io.DataOutputStream;
import java.io.InputStream;
import java.io.OutputStream;
import java.net.ServerSocket;
import java.net.Socket;

public class Server {
	public static void main(String[] args) {
		ServerSocket serverSocket = new ServerSocket(9876);
		do {
		    Socket socket = serverSocket.accept();
		    InputStream input = socket.getInputStream();
		    DataInputStream dis = new DataInputStream(input);
		    OutputStream output = socket.getOutputStream();
		    DataOutputStream dos = new DataOutputStream(output);

		    double altura = dis.readFloat();
		    double peso = dis.readFloat();
		    double imc = peso / (altura*altura);
		    dos.writeDouble(imc);
		    socket.close();
		    System.out.println("Disconnected. ");
		} while (true);
	}
}
