#CALEB OSHUST
import socket
import threading
import random
import json


def generate_random_characters(count=20):
    characters = [random.choice('abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ') for _ in range(count)]
    return characters

def handle_client(client_socket, address):
    print(f"Connection established with {address}")
    try:
        # Generate and send a random list of characters
        random_characters = generate_random_characters()
        client_socket.sendall(json.dumps(random_characters).encode('utf-8'))

        # Receive response from the client
        data = client_socket.recv(1024)
        if data:
            print(f"Client response: {data.decode('utf-8')}")
    except Exception as e:
        print(f"Error handling client {address}: {e}")
    finally:
        client_socket.close()
        print(f"Connection closed with {address}")


def start_server(host='localhost', port=5000):
    server_socket = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
    server_socket.bind((host, port))
    server_socket.listen(10)
    print(f"Server listening on {host}:{port}")

    try:
        while True:
            client_socket, address = server_socket.accept()
            client_thread = threading.Thread(target=handle_client, args=(client_socket, address))
            client_thread.start()
    except KeyboardInterrupt:
        print("\nShutting down server.")
    finally:
        server_socket.close()

if __name__ == '__main__':
    start_server()
