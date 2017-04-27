FROM nginx

# Remove the default Nginx configuration file and
# copy a configuration file from the current directory.
RUN rm -v /etc/nginx/nginx.conf
ADD nginx.conf /etc/nginx/

EXPOSE 80
CMD ["nginx"]
