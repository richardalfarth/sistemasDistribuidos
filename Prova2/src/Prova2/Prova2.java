package Prova2;

import javax.jms.*;
import javax.naming.InitialContext;
import java.util.Scanner;

public class Prova2 {
	public static void main(String[] args) {
		InitialContext context = new InitialContext();
		ConnectionFactory factory = (ConnectionFactory) context.lookup("ConnectionFactory");

		Connection connection = factory.createConnection();
		connection.start();
		Session session = connection.createSession(false, Session.AUTO_ACKNOWLEDGE);

		Topic destino = (Topic) context.lookup("passagens_vendidas");

		MessageProducer producer = session.createProducer(destino);
		Scanner teclado = new Scanner(System.in);

		String aeroporto;
		byte tipoDestino;
		do {
		    System.out.println("Tipo de destino (1-Nacional, 2-Internacional ou 0-sair?");
		    tipoDestino = Byte.parseByte(teclado.nextLine());
		    if (tipoDestino > 0) {
		        System.out.print("Viagem para qual destino? ");
		        aeroporto = teclado.nextLine();
		        Message message = session.createTextMessage("{\"destino\":\"" +
		                aeroporto + "\"}");
		        message.setByteProperty("tipoDestino", tipoDestino);
		        producer.send(message);
		    }
		} while (tipoDestino > 0);
		System.out.println("Fim");
	}
}
